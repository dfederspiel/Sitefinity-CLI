/* ------------------------------------------------------------------------------
<auto-generated>
    This file was generated by Sitefinity CLI v1.0.0.7
</auto-generated>
------------------------------------------------------------------------------ */

using System.Collections.Specialized;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Modules.GenericContent.Configuration;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Configuration;
using Telerik.Sitefinity.Web.UI.ContentUI.Config;

namespace Test
{
    internal class TestModuleConfig : ContentModuleConfigBase
    {
        protected override void InitializeDefaultViews(ConfigElementDictionary<string, ContentViewControlElement> contentViewControls)
        {
            contentViewControls.Add(TestModuleDefinition.BackendDefinitionName,
                TestModuleDefinition.DefineTestBackendContentView(contentViewControls));

        }

        protected override void InitializeDefaultProviders(ConfigElementDictionary<string, DataProviderSettings> providers)
        {
            providers.Add(new DataProviderSettings(providers)
            {
                Name = "OpenAccessDataProvider",
                Description = "A provider that stores Test module data in database using OpenAccess ORM.",
                ProviderType = typeof(OpenAccessTestModuleProvider),
                Parameters = new NameValueCollection() { { "applicationName", "/Test" } }
            });
        }

        protected override void OnPropertiesInitialized()
        {
            base.OnPropertiesInitialized();

            InitializeDefaultPermissions();
        }

        protected virtual void InitializeDefaultPermissions()
        {
            var permission = new Permission(Permissions)
            {
                Name = "Test",
                Title = "Test",
            };
            Permissions.Add(permission);

            permission.Actions.Add(new SecurityAction(permission.Actions)
            {
                Name = "View",
                Type = SecurityActionTypes.View,
                Title = "View Test",
            });

            var customPermissionsDisplaySettings = CustomPermissionsDisplaySettings;
            var generalCustomSet = new CustomPermissionsDisplaySettingsConfig(customPermissionsDisplaySettings)
            {
                SetName = SecurityConstants.Sets.General.SetName
            };
            customPermissionsDisplaySettings.Add(generalCustomSet);

            var newsCustomActions = new SecuredObjectCustomPermissionSet(generalCustomSet.SecuredObjectCustomPermissionSets)
            {
                TypeName = typeof(TestModuleItem).FullName
            };
            generalCustomSet.SecuredObjectCustomPermissionSets.Add(newsCustomActions);

            var newsCreateAction = new CustomSecurityAction(newsCustomActions.CustomSecurityActions)
            {
                Name = SecurityConstants.Sets.General.Create,
                ShowActionInList = false
            };
            newsCustomActions.CustomSecurityActions.Add(newsCreateAction);

            var newsModifyAction = new CustomSecurityAction(newsCustomActions.CustomSecurityActions)
            {
                Name = SecurityConstants.Sets.General.Modify,
                ShowActionInList = true,
                Title = "ModifyThisItem",
                ResourceClassId = typeof(SecurityResources).Name
            };
            newsCustomActions.CustomSecurityActions.Add(newsModifyAction);

            var newsViewAction = new CustomSecurityAction(newsCustomActions.CustomSecurityActions)
            {
                Name = SecurityConstants.Sets.General.View,
                ShowActionInList = true,
                Title = "ViewThisItem",
                ResourceClassId = typeof(SecurityResources).Name
            };
            newsCustomActions.CustomSecurityActions.Add(newsViewAction);

            var newsDeleteAction = new CustomSecurityAction(newsCustomActions.CustomSecurityActions)
            {
                Name = SecurityConstants.Sets.General.Delete,
                ShowActionInList = true,
                Title = "DeleteThisItem",
                ResourceClassId = typeof(SecurityResources).Name
            };
            newsCustomActions.CustomSecurityActions.Add(newsDeleteAction);

            var newsChangeOwnerAction = new CustomSecurityAction(newsCustomActions.CustomSecurityActions)
            {
                Name = SecurityConstants.Sets.General.ChangeOwner,
                ShowActionInList = true,
                Title = "ChangeOwnerOfThisItem",
                ResourceClassId = typeof(SecurityResources).Name
            };
            newsCustomActions.CustomSecurityActions.Add(newsChangeOwnerAction);
        }
    }
}