# How To Create and Deploy a Release

For user convenience a decision was made to use a commercial installer tool that
requires an inexpensive license. 

## General Flow
 * Make whatever code changes.
 * Update version number in correct places.
 * Rebuild C# project.
 * Rebuilt installer.
 * Update docs as needed.
 * Commit to GitHub.

## Version Number Locations
 * Properties/AssemblyInfo.cs
 * docs/_config.yml
 * Version setting in Actual Installer project artifacts/CorionisServiceManager.NET.aip

