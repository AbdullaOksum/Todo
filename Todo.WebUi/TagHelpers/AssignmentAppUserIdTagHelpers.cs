using Microsoft.AspNetCore.Razor.TagHelpers;
using Todo.Business.Interface;
using Todo.Entities.Concrete;

namespace Todo.WebUi.TagHelpers
{
    [HtmlTargetElement("GetAssignmentAppUserId")]
    public class AssignmentAppUserIdTagHelpers : TagHelper
    {
        private readonly IAssignmentService _AssignmentService;

        public AssignmentAppUserIdTagHelpers(IAssignmentService AssignmentService)
        {
            _AssignmentService = AssignmentService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Assignment> Assignments = _AssignmentService.GetAppUserId(AppUserId);
            int completetCount = Assignments.Where(x => x.Situation).Count();
            int nonCompletetCount = Assignments.Where(x => x.Situation == false).Count();

            string htmlstring = $"<strong>Antal færdig gjordte opgaver : </strong> " +
                $"{completetCount} <br><strong>Antal igangværende opgaver: " +
                $"</strong>{completetCount}";

            output.Content.SetHtmlContent(htmlstring);

        }
    }
}
