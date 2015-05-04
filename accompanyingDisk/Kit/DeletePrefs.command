#!/bin/bash

cd "`dirname "$0"`"

find . -iname "prefs.cs" -print0 | xargs -0 rm -fv
find . -iname "config.cs" -print0 | xargs -0 rm -fv
find . -iname "prefs.cs.dso" -print0 | xargs -0 rm -fv
find . -iname "config.cs.dso" -print0 | xargs -0 rm -fv
