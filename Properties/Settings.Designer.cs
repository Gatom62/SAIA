﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgroServicios.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=SQL8006.site4now.net;Initial Catalog=db_aab115_siasbase;Persist Secur" +
            "ity Info=True;User ID=db_aab115_siasbase_admin;Password=MichI#12@3;Encrypt=True")]
        public string db_aab115_siasbaseConnectionString {
            get {
                return ((string)(this["db_aab115_siasbaseConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=SQL8020.site4now.net;Initial Catalog=db_aace33_basesaias2;Persist Sec" +
            "urity Info=True;User ID=db_aace33_basesaias2_admin;Password=MichI123;Encrypt=Fal" +
            "se")]
        public string db_aace33_basesaias2ConnectionString {
            get {
                return ((string)(this["db_aace33_basesaias2ConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=SQL8020.site4now.net;Initial Catalog=db_aace33_saias3;Persist Securit" +
            "y Info=True;User ID=db_aace33_saias3_admin;Password=MichI123;TrustServerCertific" +
            "ate=True")]
        public string db_aace33_saias3ConnectionString {
            get {
                return ((string)(this["db_aace33_saias3ConnectionString"]));
            }
        }
    }
}
