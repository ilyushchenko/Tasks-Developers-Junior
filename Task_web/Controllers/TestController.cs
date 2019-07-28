using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task_web.Models;

namespace Task_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IList<TestModel> _testModels;

        public TestController(IList<TestModel> testModels)
        {
            _testModels = testModels;
        }

        /// <summary>
        /// Возвращает коллекцию моделей
        /// </summary>
        /// <param name="count">Количество результатов выдачи</param>
        /// <param name="skip">Пропуск результатов выдачи</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<TestModel[]> GetAll(int count = 100, int skip = 0)
        {
            return _testModels.Skip(skip).Take(count).ToArray();
        }

        /// <summary>
        /// Возвращает конкретную модель по ID
        /// </summary>
        /// <param name="id">Идентификатор модели</param>
        /// <returns></returns>
        [HttpGet("{id:Guid}")]
        public ActionResult<TestModel> GetById(Guid id)
        {
            var model = _testModels.FirstOrDefault(m => m.Id == id);
            return model == null ? NotFound() : (ActionResult<TestModel>)model;
        }

        /// <summary>
        /// Создает <see cref="TestModel"/>
        /// </summary>
        /// <param name="model">Данные модели</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<TestModel> Create([FromBody]TestModel model)
        {
            if (model == null)
            {
                ModelState.AddModelError("emptyModel", "Необходимо указать данные");
                return BadRequest(ModelState);
            }

            ValidateModel(model);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            model.Id = Guid.NewGuid();
            _testModels.Add(model);
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        /// <summary>
        /// Обновляет данные <see cref="TestModel"/>
        /// </summary>
        /// <param name="id">Идентификатор модели</param>
        /// <param name="model">Данные модели</param>
        /// <returns></returns>
        [HttpPut("{id:Guid}")]
        public ActionResult<TestModel> Update(Guid id, [FromBody]TestModel model)
        {
            if (model == null)
            {
                ModelState.AddModelError("emptyModel", "Необходимо указать данные");
                return BadRequest(ModelState);
            }
            if (model.Id != id)
            {
                ModelState.AddModelError("invalidId", "Указан неправильный идентификатор");
                BadRequest(ModelState);
            }

            var dbModel = _testModels.FirstOrDefault(m => m.Id == id);
            if (dbModel == null)
                return NotFound();

            ValidateModel(model);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var index = _testModels.IndexOf(dbModel);
            _testModels[index] = model;

            return new NoContentResult();
        }

        /// <summary>
        /// Удаляет модель по Id
        /// </summary>
        /// <param name="id">Идентификатор модели</param>
        /// <returns></returns>
        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            var model = _testModels.FirstOrDefault(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            _testModels.Remove(model);
            return new NoContentResult();
        }

        #region Helpers

        private void ValidateModel(TestModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("emptyName", "Укажите Name");
            }
        }

        #endregion


        /*
         *
         * необходимо релизовать CRUD для testModels
         *
         */
    }
}
