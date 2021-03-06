namespace System.Management.Automation
{
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Reflection;
    using System.Security;
    using System.Xml;

    internal class GeneralHelpProvider : HelpProviderWithFullCache
    {
        private readonly Hashtable _helpFiles;

        internal GeneralHelpProvider(HelpSystem helpSystem) : base(helpSystem)
        {
            this._helpFiles = new Hashtable();
        }

        internal sealed override void LoadCache()
        {
            Collection<string> collection = MUIFileSearcher.SearchFiles("*.concept.xml", base.GetSearchPaths());
            if (collection != null)
            {
                foreach (string str in collection)
                {
                    if (!this._helpFiles.ContainsKey(str))
                    {
                        this.LoadHelpFile(str);
                        this._helpFiles[str] = 0;
                    }
                }
            }
        }

        private void LoadHelpFile(string helpFile)
        {
            if (!string.IsNullOrEmpty(helpFile))
            {
                XmlDocument document;
                try
                {
                    document = InternalDeserializer.LoadUnsafeXmlDocument(new FileInfo(helpFile), false, null);
                }
                catch (IOException exception)
                {
                    ErrorRecord item = new ErrorRecord(exception, "HelpFileLoadFailure", ErrorCategory.OpenError, null) {
                        ErrorDetails = new ErrorDetails(Assembly.GetExecutingAssembly(), "HelpErrors", "HelpFileLoadFailure", new object[] { helpFile, exception.Message })
                    };
                    base.HelpSystem.LastErrors.Add(item);
                    return;
                }
                catch (SecurityException exception2)
                {
                    ErrorRecord record2 = new ErrorRecord(exception2, "HelpFileNotAccessible", ErrorCategory.OpenError, null) {
                        ErrorDetails = new ErrorDetails(Assembly.GetExecutingAssembly(), "HelpErrors", "HelpFileNotAccessible", new object[] { helpFile, exception2.Message })
                    };
                    base.HelpSystem.LastErrors.Add(record2);
                    return;
                }
                catch (XmlException exception3)
                {
                    ErrorRecord record3 = new ErrorRecord(exception3, "HelpFileNotValid", ErrorCategory.SyntaxError, null) {
                        ErrorDetails = new ErrorDetails(Assembly.GetExecutingAssembly(), "HelpErrors", "HelpFileNotValid", new object[] { helpFile, exception3.Message })
                    };
                    base.HelpSystem.LastErrors.Add(record3);
                    return;
                }
                System.Xml.XmlNode node = null;
                if (document.HasChildNodes)
                {
                    for (int i = 0; i < document.ChildNodes.Count; i++)
                    {
                        System.Xml.XmlNode node2 = document.ChildNodes[i];
                        if ((node2.NodeType == XmlNodeType.Element) && (string.Compare(node2.Name, "conceptuals", StringComparison.OrdinalIgnoreCase) == 0))
                        {
                            node = node2;
                            break;
                        }
                    }
                }
                if (node != null)
                {
                    using (base.HelpSystem.Trace(helpFile))
                    {
                        if (node.HasChildNodes)
                        {
                            for (int j = 0; j < node.ChildNodes.Count; j++)
                            {
                                System.Xml.XmlNode xmlNode = node.ChildNodes[j];
                                if ((xmlNode.NodeType == XmlNodeType.Element) && (string.Compare(xmlNode.Name, "conceptual", StringComparison.OrdinalIgnoreCase) == 0))
                                {
                                    HelpInfo helpInfo = null;
                                    helpInfo = GeneralHelpInfo.Load(xmlNode);
                                    if (helpInfo != null)
                                    {
                                        base.HelpSystem.TraceErrors(helpInfo.Errors);
                                        base.AddCache(helpInfo.Name, helpInfo);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        internal override void Reset()
        {
            base.Reset();
            this._helpFiles.Clear();
        }

        internal override System.Management.Automation.HelpCategory HelpCategory
        {
            get
            {
                return System.Management.Automation.HelpCategory.General;
            }
        }

        internal override string Name
        {
            get
            {
                return "General Help Provider";
            }
        }
    }
}

