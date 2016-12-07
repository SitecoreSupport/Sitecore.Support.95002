using Sitecore.Pipelines.RenderField;
using System;

namespace Sitecore.Support.Pipelines.RenderField
{
    /// <summary>
    /// Implements the RenderField.
    /// </summary>
    public class GetMemoFieldValue
    {
        /// <summary>
        /// Gets the field value.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public void Process(RenderFieldArgs args)
        {
            string fieldTypeKey = args.FieldTypeKey;
            if (fieldTypeKey != "memo" && fieldTypeKey != "multi-line text")
            {
                return;
            }
            string text = args.RenderParameters["line-breaks"];
            string text2 = text ?? args.RenderParameters["linebreaks"];
            if (text2 == null)
            {
                text2 = "<br/>";
            }
            args.Result.FirstPart = GetMemoFieldValue.Replace(args.Result.FirstPart, text2);
            args.Result.LastPart = GetMemoFieldValue.Replace(args.Result.LastPart, text2);
        }

        /// <summary>
        /// Replaces the specified linebreaks.
        /// </summary>
        /// <param name="linebreaks">The linebreaks.</param>
        /// <param name="output">The output.</param>
        /// <returns>The replace.</returns>
        private static string Replace(string output, string linebreaks)
        {
            output = output.Replace("\r\n", linebreaks);
            output = output.Replace("\n\r", linebreaks);
            output = output.Replace("\n", linebreaks);
            output = output.Replace("\r", linebreaks);
            return output;
        }
    }
}