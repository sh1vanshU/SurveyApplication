using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurveyApplication.Models;
namespace SurveyApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult SurveyQuestion()
        {
            QuestionItem questionData = new QuestionItem
            {
                ListQuestionModel = new List<QuestionViewModel>()

            };
            surveyEntities entity = new surveyEntities();
            var questionTable = entity.QuestionTables.ToList();
            foreach (var list in questionTable)
            {
                QuestionViewModel obj = new QuestionViewModel();
                obj.Question_ID = list.Question_ID;
                obj.Question = list.Question;
                questionData.ListQuestionModel.Add(obj);
            }
            return View(questionData);
        }
        [HttpPost]
        public ActionResult SurveyQuestion(List<QuestionViewModel> list)
        {
            surveyEntities entity = new surveyEntities();
            List<AnswerTable> objectTable = new List<AnswerTable>();
            try
            {
                foreach (var questionData in list)
                {
                    AnswerTable obj = new AnswerTable();
                    obj.Question_ID = questionData.Question_ID;
                    obj.SelectedAnswer = questionData.SelectedAnswer;
                    obj.User_ID = 1027;
                    obj.Survey_ID = 1;
                    objectTable.Add(obj);
                }
            }
            catch
            {
                return View(list);
            }
            foreach (var item in objectTable)
            {
                entity.AnswerTables.Add(item);
                entity.SaveChanges();
            }
            return View();

        }
        [HttpGet]
        public ActionResult AddSurvey()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSurvey(AddSurveyViewModel addSurveyView)
        {
            using (var context = new surveyEntities())
            {
                SurveyTable surveyTable = new SurveyTable();
                surveyTable.Survey_Type = addSurveyView.Survey_Type;
                context.SurveyTables.Add(surveyTable);
                context.SaveChanges();
            }
            return RedirectToAction("AddSurvey");
        }
        [HttpGet]
        public ActionResult AddQuestion()
        {
            
            using (var cshparpEntity = new surveyEntities())
            {
                List<SelectListItem> surveys = new List<SelectListItem>();

                foreach (var temp in cshparpEntity.SurveyTables.ToList())
                {
                    surveys.Add(new SelectListItem() { Text = temp.Survey_Type, Value = temp.Survey_ID.ToString() });
                }
                ViewData["DBMySkills"] = surveys;
            }
            return View();

        }
        [HttpPost]
        public ActionResult AddQuestion(AddQuestionViewModel addQuestionViewModel)
        {
            using (var context = new surveyEntities())
            {
                QuestionTable questionTable = new QuestionTable();
                questionTable.Question = addQuestionViewModel.Question;
                questionTable.Survey_ID = addQuestionViewModel.Survey_ID;
                context.QuestionTables.Add(questionTable);
                context.SaveChanges();
            }
            return View();
        }

    }
}