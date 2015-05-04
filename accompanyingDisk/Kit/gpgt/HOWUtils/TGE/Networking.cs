//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
echo("\n--------- Loading Networking Utilities ---------");
//// 
// Server to Client - Action Map push/pop
////
function pushActionMapOnClient( %client , %mapName ) {
	commandToClient( %client, 'pushActionMap', %mapName );
}

function clientCmdPushActionMap( %mapName ) {
    if(!isObject(%mapMap)) return;
	%mapMap.getID().push();
}


function popActionMapOnClient( %client , %mapName ) {
	commandToClient( %client, 'popActionMap', %mapName );
}

function clientCmdPopActionMap( %mapName ) {
    if(!isObject(%mapMap)) return;
	%mapMap.getID().pop();
}

//// 
// Server to Client - Activate/Deactivate Package
////
function activatePackageOnClient( %client , %packageName ) {
	commandToClient( %client, 'activatePackage', %packageName );
}

function clientCmdActivatePackage( %packageName ) {
	activatePackage( %packageName  );
}


function deactivatePackageOnClient( %client , %packageName ) {
	commandToClient( %client, 'deactivatePackage', %packageName );
}

function clientCmdDeactivatePackage( %packageName ) {
	deactivatePackage( %packageName  );
}




