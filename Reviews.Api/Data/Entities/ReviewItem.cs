using System;

namespace Reviews.Api.Data.Entities
{
    public class ReviewItem
    {
        public bool IsQuestion { get; set; } // if false display stars else textbox

        public string Name { get; set; }

        public Single Rating { get; set; }

        public string QuestionAnswer { get; set; } // if isquestion is true then the answer to the question will be here.

    }
}