# How To Create and Deploy a Release

There are notes for contributors, but most of this is for the original developer.
For user convenience a decision was made to use a commercial installer tool that
requires a license. And frankly I don't really expect anyone else to contribute.

Additionally, if you fork this project the installer can be replaced easily.

# For Contributors
If you modify this code and would like to incorporate your changes to this project
please use the Pull Request mechanism after your commits. I will review the proposed
changes and will incorporate them and rebuilt the installer for distribution.

General flow:
 * Make whatever code changes.
 * Update version number in correct places.
 * Rebuild C# project.
 * Rebuilt installer.
 * Commit to GitHub.

## Version Number Locations
 * Properties/AssemblyInfo.cs
 * docs/_config.yml
 * Version setting in Actual Installer project artifacts/CorionisServiceManager.NET.aip

