# MobileMemoryManagement
 experiments with memory allocation in Unity for mobile
 
 These different projects/demos exist:
 
 
                                                      Direct Referencing Instance


1
Reference a gameobject in a Build‘s Scene. Toggle it.

                                                      Direct Referencing


2
Reference an asset in a Build‘s Scene. Instantiate it. Destroy it when switching.

                                                      Separate Scene


3
Load another scene containing the asset.

                                                      Resources


4
Put an asset in a Resources-Folder. Load and Instantiate it using its path. Destroy it when switching.

                                                      StreamingAssets


5
Put an asset in a StreamingAssets-Folder. Load and Instantiate it using it path. Destroy it when switching.



                           AssetBundles


6
Put the skyboxes in separate AssetBundles. Build the AssetBundles to StreamingAssets. Load an Asset Bundle and the containing Asset. Instantiate it. Unload the AssetBundle when switching.



            Addressables (modern AssetBundles)


6
Similar to AssetBundles. But use Addressables.
