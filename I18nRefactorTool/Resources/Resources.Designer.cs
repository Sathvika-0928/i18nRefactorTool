namespace I18nRefactorTool {
    using System;
    using System.Resources;

    public class Resources {

        private static ResourceManager resourceMan;

        public static string WelcomeUser {
            get {
                return ResourceManager.GetString("WelcomeUser", null);
            }
        }

        private static ResourceManager ResourceManager {
            get {
                if (resourceMan == null) {
                     resourceMan = new ResourceManager("I18nRefactorTool.Resources.Resources", typeof(Resources).Assembly);
                }
                return resourceMan;
            }
        }
    }
}
