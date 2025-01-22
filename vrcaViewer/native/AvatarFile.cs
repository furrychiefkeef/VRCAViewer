using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AssetsTools.NET.Extra;
using AssetsTools.NET;
using Pastel;

namespace vrcaViewer.native;
internal class AvatarFile
{
    static string? _avtr;
    public static string? GetAvatarID(string assetbundle)
    {
        AssetsManager? manager = new AssetsManager();

        BundleFileInstance? bunInst = manager.LoadBundleFile(filePath, true);
        if (bunInst != null)
        {
            Console.WriteLine("Failed to load bundle file or it's not reconizable.");
            return null;
        }

        AssetsFileInstance? afileInst = manager.LoadAssetsFileFromBundle(bunInst, 0, false);
        if (afileInst == null)
        {
            Console.WriteLine("Failed to load assets file from bundle.");
            return null;
        }

        AssetsFile? afile = afileInst.file;
        if (afile == null)
        {
            Console.WriteLine("Failed to access assets file.");
            return null;
        }

        foreach (AssetFileInfo texInfo in afile.GetAssetsOfType((int)AssetClassID.GameObject))
        {
            AssetTypeValueField? texBase = manager.GetBaseField(afileInst, texInfo);
            if (texBase == null)
            {
                Console.WriteLine("Failed to get base field for asset.");
                continue;
            }

            var name = texBase.Get("m_Name").AsString;
            if (name.StartsWith("prefab-id"))
            {
                string _p = "prefab-id-v1_";
                if (name.StartsWith(_p))
                {
                    string avtr = name.Substring(_p.Length);
                    if (!File.Exists(avtr))
                    {
                        File.Create(avtr + ";;JUST_ID");
                        Console.WriteLine("avtr_id sent in ur files");
                        Console.WriteLine();
                    }
                    Console.Clear();
                    Console.WriteLine($"avatar id::<{avtr.Pastel("#ff0058")}>");
                    Console.ReadLine();
                    _avtr = avtr;
                    return avtr;
                }
            }
        }
        return null;
    }
    public static string? ExtractTextures(string assetbundle)
    {
        AssetsManager manager = new();
        
        BundleFileInstance BFI = manager.LoadBundleFile(assetbundle);
        if(BFI == null) { Console.WriteLine("Unrecognizable"); }

        AssetsFileInstance AFI = manager.LoadAssetsFileFromBundle(BFI,0);
        if (BFI == null) { Console.WriteLine("Unrecognizable"); }

        return null;
    } 
}






