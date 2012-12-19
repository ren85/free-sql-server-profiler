using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;
using AnfiniL.SqlExpressProfiler.Properties;

namespace AnfiniL.SqlExpressProfiler
{
    static class UpdatesChecker
    {
        static readonly Regex VersionRegex = new Regex(@"SqlExpressProfiler-(?<Version>(?<Major>\d+)\.(?<Minor>\d+)\.(?<Build>\d+)\.(?<Revision>\d+))");

        public static Version CurrentAssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        public static Version GetLatestVersion()
        {
            List<Version> versions = new List<Version>();
            try
            {
                HttpWebRequest req =
                    (HttpWebRequest) WebRequest.Create("http://code.google.com/p/sqlexpressprofiler/downloads/list");
                HttpWebResponse response = (HttpWebResponse) req.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string page = reader.ReadToEnd();
                    MatchCollection matches = VersionRegex.Matches(page);
                    foreach (Match match in matches)
                    {
                        Version v = new Version(match.Groups["Version"].Value);
                        versions.Add(v);
                    }
                }
            } 
            catch
            {
                return null;
            }
            versions.Sort();
            if (versions.Count == 0)
                return new Version("0.0.0.0");
            else
                return versions[versions.Count - 1];
        }

        public static event EventHandler NewVersionIsAvailable;

        public static void StartNewVersionChecking()
        {
            if ((DateTime.Now - Settings.Default.UpdatesLastCheck).TotalDays < 7)
                return;

            Thread th = new Thread(delegate (object o) {
                                       Thread.Sleep(15 * 1000);
                                       Version latestVersion = GetLatestVersion();
                                       if (latestVersion == null)
                                           return;

                                       Settings.Default.UpdatesLastCheck = DateTime.Now;

                                       if (latestVersion > CurrentAssemblyVersion && NewVersionIsAvailable != null)
                                           NewVersionIsAvailable(null, EventArgs.Empty);
                                   });

            th.IsBackground = true;
            th.Priority = ThreadPriority.BelowNormal;

            th.Start();
        }
    }
}
