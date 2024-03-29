﻿using GlobantTraining.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlobantTraining.Models.Dtos;
using GlobantTraining.Business.Abstract;

namespace GlobantTraining.Controllers
{
    public class ConsumablesController : Controller
    {
        private readonly IConsumableBusiness _consumableBusiness;
        public ConsumablesController(IConsumableBusiness consumableBusiness)
        {
            _consumableBusiness = consumableBusiness;
        }
        public async Task <IActionResult> Index()
        {
            ViewBag.Titulo = "Insumos";
            return View(await _consumableBusiness.GetConsumables());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Titulo = "Crear Insumo";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConsumableDto consumableDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.Titulo = "Crear Insumo";
                    _consumableBusiness.Create(consumableDto);
                    var save = await _consumableBusiness.SaveChanges();
                    if (save)
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return View(consumableDto);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                try
                {
                    var consumable = await _consumableBusiness.GetConsumableId(id.Value);
                    if (consumable != null)
                    {
                        ViewBag.Titulo = "Editar Insumo";
                        return View(consumable);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ConsumableDto consumableDto)
        {
            if (id != consumableDto.ConsumableId)
            {
                try
                {
                    _consumableBusiness.Edit(consumableDto);
                    var edit = await _consumableBusiness.SaveChanges();
                    if (edit)
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _consumableBusiness.Edit(consumableDto);
                    var edit = await _consumableBusiness.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_consumableBusiness.ConsumableExists(consumableDto.ConsumableId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(consumableDto);
        }

       
    }

}
