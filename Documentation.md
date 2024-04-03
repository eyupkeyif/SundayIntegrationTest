# SundayIntegrationTest

## ChangeLog ##

#Graphic Changes:
 1- Reduced pixel light count from 4 to 1. Hence it's a mobile project, increasing pixel light count can cause performance issues.
 2- Anti aliasing disabled.

#Code Changes:
 1- Removed unnecessary computations in Update/FixedUpdate methods. (e.g. created a reference for playerball in Start method and use it in Update instead of trying to find the playerball in the Hierarchy in every frame.)
 2- Created an Event Manager script to handle success and fail situations.
 3- Created an Asset Manager to load assets in the project and use it easily in scripts.
 4- Created a Generic Singleton script for accessing Asset Manager easily. (It also can be useful for further features.)

#Level Designs:
 1- Created a Scriptable Object to hold the data of the levels.
 2- Instead of loading scenes for the levels, created a Level Manager script to instantiate and destroy levels.
 3- Added a simple save system for levels. 

#Firebase Analytics:
 1-Firebase Analytics added to the project.

 
##Removed unnecessary file in the project that cause errors and prevents to work Game Analytics correctly.
##Organised folders.

## Test apk is in the Build/Android folder.
