//
//	Do you like this project? Do you find it helpful? Pay it forward by hiring me as a consultant!
//  https://jason-iverson.com
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace JM0ney.Framework {

    /// <summary>
    /// Utility class to assist with reading from web.config and app.config files
    /// </summary>
    public static class ConfigurationHelper {

        /// <summary>
        /// Returns a boolean indicating if the associated AppSetting is configured.
        /// </summary>
        /// <param name="settingName">The AppSetting key</param>
        /// <param name="errorMessage">Error message returned</param>
        /// <param name="valueIsRequired"></param>
        /// <returns></returns>
        public static bool IsAppSettingConfigured( String settingName, ref String errorMessage, bool valueIsRequired = true ) {
            bool returnValue = false;
            if ( String.IsNullOrWhiteSpace( settingName ) ) {
                errorMessage = Localization.ConfigurationHelper.ErrorMessages.NoSettingNameProvided;
            }
            else {
                if ( valueIsRequired ) {
                    if ( ConfigurationManager.AppSettings[ settingName ] == null ) {
                        errorMessage = String.Format( Localization.ConfigurationHelper.ErrorMessages.SettingMissing_FS, settingName );
                    }
                    else if ( String.IsNullOrWhiteSpace( ConfigurationManager.AppSettings[ settingName ] ) ) {
                        errorMessage = String.Format( Localization.ConfigurationHelper.ErrorMessages.SettingEmpty_FS, settingName );
                    }
                    else {
                        // There's an entry and its value is non-empty
                        returnValue = true;
                    }
                }
                else {
                    returnValue = ConfigurationManager.AppSettings[ settingName ] != null && !String.IsNullOrWhiteSpace( ConfigurationManager.AppSettings[ settingName ] );
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Retrieves a value from the web.config or app.config file
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="settingName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TType TryGetValue<TType>( String settingName, TType defaultValue ) {
            TType returnValue = defaultValue;
            String valueRead = ConfigurationManager.AppSettings[ settingName ];
            if ( !String.IsNullOrWhiteSpace( valueRead ) ) {
                returnValue = ( TType ) Convert.ChangeType( valueRead, returnValue.GetType() );
            }
            return returnValue;
        }

    }

}
