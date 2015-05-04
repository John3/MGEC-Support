#!/usr/bin/perl -w

#
# Torque Master Server Prototype
# ------------------------------
# 
# Free for all for any use
# This is only useful for proof of concept or a starting point to ode your own
# I would advice against using this in production
#
# Author: Thomas Lund, thomas@trylleskoven.dk, www.c3command.com
#

use strict;
use IO::Socket;

my $MAXLEN = 1024;
my $PORT = 28002;

my $sock = IO::Socket::INET->new(LocalPort => $PORT,
				 Proto => 'udp')
  or die "socket: $@";

my %gameServers;

print "Listening for game servers on port $PORT\n";

while ($sock->recv(my $newmsg, $MAXLEN)) {
    my($port, $ipaddr) = sockaddr_in($sock->peername);
    my $gameserverIP = join(".", unpack("C4", $ipaddr));

    # Retrieve the command type from the request
    my ($cmd_type) = unpack("C1",$newmsg);

    # Heartbeat from game servers = 22
    # Add the server to the gameServers hash array
    if ($cmd_type eq "22") {
	print "Heartbeat recieved from $gameserverIP\n";
	$gameServers{$ipaddr} = $port;

    # Game Server list request = 6
    # The request contains tons of flags to filter the response list created
    # Here I just dump it all on the console and return a complete list of servers
    } elsif ($cmd_type eq "6") {
	print "Server list request from $gameserverIP\n";
	my ($cmd_type, $query_flags, $key, $dummy, $gametype_size) = unpack("C1 C1 i1 C1 C1", $newmsg);
	print "  Qflags: $query_flags\n";
	print "  Key: $key\n";
	print "  Gametype_size: $gametype_size\n";
	my $gametype = substr($newmsg,8,$gametype_size);
	print "  Gametype: '$gametype'\n";
	my $misstype_size = unpack("C1", substr($newmsg,8+$gametype_size,1));
	print "  Missiontype_size: $misstype_size\n";
	my $misstype = substr($newmsg, 8+$gametype_size+1, $misstype_size);
	print "  Missiontype: $misstype\n";
	my ($min_players, $max_players, $reg_mask, $version, $filterflag, $maxbot, $mincpu, $buddycount) = unpack("C1 C1 I1 I1 C1 C1 S1 C1", substr($newmsg, 8+$gametype_size+1+$misstype_size));
	print "  Min play: $min_players\n";
	print "  Max play: $max_players\n";
	print "  Region mask: $reg_mask\n";
	print "  Version: $version\n";
	print "  Filter flag: $filterflag\n";
	print "  Max bots: $maxbot\n";
	print "  Min CPU: $mincpu\n";
	print "  Buddy Count: $buddycount\n";
	sendServerList($key);

    # Unknown request = everything else
    } else {
      print "Unknown request type $cmd_type\n";
    }
} 
die "recv: $!";

#
# Takes a request key as parameter and returns complete list of all game servers
#
sub sendServerList {
  my ($packetkey) = @_;

  # Game server list response = type 8
  my $packettype = 8;
  my $flag = 0;
  my $key = $packetkey;

  # Check number of servers
  my $packetindex = 0;
  my $servercount = scalar keys(%gameServers);

  # If there are servers, then populate list and send it back
  if ($servercount != 0) {
    my $packettotal = $servercount;

    # Loop over all servers
    foreach my $ip (keys %gameServers) {
      
      my ($ip1, $ip2, $ip3, $ip4) = unpack("C4",$ip);
      my $port = $gameServers{$ip};
      # Create single server info packet
      my $serverResponse = pack("C1 C1 I1 C1 C1 S1 C1 C1 C1 C1 S1", 
				$packettype,
				$flag,
				$key,
				$packetindex,
				$packettotal,
				$servercount,
				$ip1, $ip2, $ip3, $ip4,
				$port);
      print "Sending serverlist part $packetindex of $packettotal\n";
      $sock->send($serverResponse) or die "send: $!";      
      $packetindex++;
    }

  # Empty server list
  } else {      
    my $packettotal = 1;
      my $emptyServerResponse = pack("C1 C1 I1 C1 C1 S1 C1 C1 C1 C1 S1", 
				     $packettype,
				     $flag,
				     $key,
				     $packetindex,
				     $packettotal,
				     $servercount,
				     0, 0, 0, 0,
				     0);
      print "Sending empty server list\n";
      $sock->send($emptyServerResponse) or die "send: $!";
    }
}
