using System.Collections.Generic;
using Umbraco.Core.Services;
using Umbraco.Web.HealthCheck;
using Umbraco.Web.HealthCheck.Checks.Config;

namespace Our.Umbraco.HealthChecks.Privacy.Checks.Privacy
{
    [HealthCheck("4E7B05BE-F77D-4B8A-8E77-F0FB96E0BDF8", "Privacy Policy Check - (from Our.Umbraco.HealthChecks.Privacy)",
        Description = "Check to ensure a Privacy Policy is selected.",
        Group = "Privacy")]
    public class PrivacyPolicyCheck : AbstractConfigCheck
    {
        public PrivacyPolicyCheck(ILocalizedTextService textService)
            : base(textService)
        { }

        public override string FilePath => "~/Web.config";

        public override string XPath => "/configuration/appSettings/add[@key='Our.Umbraco.HealthChecks.Privacy.PrivacyPolicyUDI']/@value";

        public override ValueComparisonType ValueComparisonType => ValueComparisonType.ShouldNotEqual;

        public override ProvidedValuePropertyType ProvidedValuePropertyType => ProvidedValuePropertyType.ContentPicker;

        public override IEnumerable<AcceptableConfiguration> Values => new List<AcceptableConfiguration>
        {
            new AcceptableConfiguration { IsRecommended = false, Value = string.Empty }
        };

        // todo: handle language files
        // public override string CheckSuccessMessage => TextService.Localize("Our.Umbraco.HealthChecks.Privacy/privacyPolicyConfigSuccess");
        public override string CheckSuccessMessage => "A Privacy Policy has been selected.";

        // todo: handle language files
        // public override string CheckErrorMessage => TextService.Localize("Our.Umbraco.HealthChecks.Privacy/privacyPolicyError");
        public override string CheckErrorMessage => "A Privacy Policy needs to be selected.";

        // todo: handle language files
        // public override string RectifySuccessMessage => TextService.Localize("Our.Umbraco.HealthChecks.Privacy/privacyPolicyRectifySuccess");
        public override string RectifySuccessMessage => "You have successfully selected a Privacy Policy.";
    }
}
