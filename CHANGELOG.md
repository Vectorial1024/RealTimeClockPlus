# Change log
This is the change log of Real Time Clock Plus. This mod follows semver versioning.

## Important notice
In the past, HugsLib was used to display update news. But, seeing the gradual lethargy of HugsLib, it was decided to disuse HugsLib going forward to minimize collateral damage from an outdated HugsLib DLL.

As such, there are several files in this repo that contains change logs:
- For changes made in 2019, see `Defs/UpdateFeatureDefs/UpdateFeatures.xml` and check for file edit history
- For changes made between 2020 and 2024, see `News/UpdateFeatures.xml` and check for file edit history
- For changes made since 2025, see this file and read on

## Dev (WIP)
As stated above, we are disusing HugsLib and striking it out on our own. This update technically counts as a backwards-breaking update, but the actual impact should be minimal.
- Removed dependency on HugsLib
  - Now depends on Harmony instead, but Harmony is already a transitive dependency
  - Mod options is remade with vanilla components instead of HugsLib components
  - This does mean previous settings are lost, but it should be easy to set them up again
  - Mod updates are no longer shown via HugsLib; you should look up the changelog files if you are interested
- Removed `Manifest.xml` for Fluffy's Mod Manager support since mod dependencies can already be handled with vanilla `About.xml`
