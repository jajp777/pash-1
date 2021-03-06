﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace System.Management.Automation {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class PSDataBufferStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PSDataBufferStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("System.Management.Automation.PSDataBufferStrings", typeof(PSDataBufferStrings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot convert value from type {0} to type {1}..
        /// </summary>
        public static string CannotConvertToGenericType {
            get {
                return ResourceManager.GetString("CannotConvertToGenericType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The index specified is less than zero or greater than the number of items in the buffer. Index should be in the range {0}-{1}..
        /// </summary>
        public static string IndexOutOfRange {
            get {
                return ResourceManager.GetString("IndexOutOfRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The SerializeInput property can only be set for PSDataCollections of PSObject. Set the SerializeInput property to false or change the collection type to be of PSObject..
        /// </summary>
        public static string SerializationNotSupported {
            get {
                return ResourceManager.GetString("SerializationNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot convert a null reference to a value type..
        /// </summary>
        public static string ValueNullReference {
            get {
                return ResourceManager.GetString("ValueNullReference", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Objects cannot be added to a closed buffer. Make sure the buffer is open for Add and Insert operations to succeed..
        /// </summary>
        public static string WriteToClosedBuffer {
            get {
                return ResourceManager.GetString("WriteToClosedBuffer", resourceCulture);
            }
        }
    }
}
