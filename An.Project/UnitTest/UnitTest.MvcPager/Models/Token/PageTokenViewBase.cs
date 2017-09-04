namespace UnitTest.MvcPager.Models.Token
{
    public abstract class PageTokenViewBase:IPageTokenView
    {
        public static readonly string HiddenTokenName = "hiddenToken";
        public static readonly string SessionMyToken = "Token";

        /// <summary>
        /// Generates the page token.
        /// </summary>
        /// <returns></returns>
        public abstract string GeneratePageToken();

        /// <summary>
        /// Gets the get last page token from Form
        /// </summary>
        public abstract string GetLastPageToken { get; }

        /// <summary>
        /// Gets a value indicating whether [tokens match].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [tokens match]; otherwise, <c>false</c>.
        /// </value>
        public abstract bool TokensMatch { get; }
    }
}