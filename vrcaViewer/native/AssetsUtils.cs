using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AssetsTools.NET.Extra;

namespace vrcaViewer.native;
internal class AssetsUtils
{
    public static AssetsManager? _makeInstance()
    {
        instance = new();
        return null;
    }
}
