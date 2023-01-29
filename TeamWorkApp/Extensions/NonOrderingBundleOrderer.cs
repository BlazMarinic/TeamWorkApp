using System.Collections.Generic;
using System.Web.Optimization;

namespace TeamWorkApp.Extensions
{
    public class NonOrderingBundleOrderer: IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }


    static class BundleExtensions
    {
        public static Bundle NonOrdering(this Bundle bundle)
        {
            bundle.Orderer=new NonOrderingBundleOrderer();
            return bundle;
        }
    }
}