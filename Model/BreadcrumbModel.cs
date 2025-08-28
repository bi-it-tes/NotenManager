namespace NotenManager.Model
{
    public class BreadcrumbModel
    {
        public string Text { get; set; }    // display name
        public string Link { get; set; }     // link to navigate

        public BreadcrumbModel(string text, string link)
        {
            Text = text;
            Link = link;
        }
    }
}
