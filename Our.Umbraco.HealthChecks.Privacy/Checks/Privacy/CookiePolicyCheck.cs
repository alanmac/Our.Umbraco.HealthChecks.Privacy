using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Services;
using Umbraco.Web.HealthCheck;
using Umbraco.Web.HealthCheck.Checks.Config;

namespace Our.Umbraco.HealthChecks.Privacy.Checks.Privacy
{
    [HealthCheck("4A616B92-AC7C-4CA0-9F77-08E8543AEC8E", "Cookie Policy Check - (from Our.Umbraco.HealthChecks.Privacy)",
        Description = "Check to ensure a Cookie Policy is selected",
        Group = "Privacy")]
    public class CookiePolicyCheck : AbstractConfigCheck
    {
        public CookiePolicyCheck(ILocalizedTextService textService)
            : base(textService)
        { }

        public override string FilePath => "~/Web.config";

        public override string XPath => "/configuration/appSettings/add[@key='Our.Umbraco.HealthChecks.Privacy.CookiePolicyUDI']/@value";

        public override ValueComparisonType ValueComparisonType => ValueComparisonType.ShouldNotEqual;

        public override ProvidedValuePropertyType ProvidedValuePropertyType => ProvidedValuePropertyType.ContentPicker;

        public override IEnumerable<AcceptableConfiguration> Values => new List<AcceptableConfiguration>
        {
            new AcceptableConfiguration { IsRecommended = false, Value = string.Empty }
        };

        // todo: handle language files
        // public override string CheckSuccessMessage => TextService.Localize("Our.Umbraco.HealthChecks.Privacy/cookiePolicyConfigSuccess");
        public override string CheckSuccessMessage => "A Cookie Policy has been selected.";

        // todo: handle language files
        // public override string CheckErrorMessage => TextService.Localize("Our.Umbraco.HealthChecks.Privacy/cookiePolicyError");
        public override string CheckErrorMessage => "A Cookie Policy needs to be selected.";
		
		// todo: handle language files
        // public override string CheckErrorMessage => TextService.Localize("Our.Umbraco.HealthChecks.Privacy/missingCookiePolicyError");
        public override string MissingErrorMessage => "Please add an appSetting with 'Our.Umbraco.HealthChecks.Privacy.CookiePolicyUDI' as a key to your web.config";

        // todo: handle language files
        // public override string RectifySuccessMessage => TextService.Localize("Our.Umbraco.HealthChecks.Privacy/cookiePolicyRectifySuccess");
        public override string RectifySuccessMessage => "You have successfully selected a Cookie Policy.";
    }
}

