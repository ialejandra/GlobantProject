using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobantTraining.DAL.Entities;
using GlobantTraining.DAL;
using GlobantTraining.Business.Abstract;
using GlobantTraining.Models.Dtos;

namespace GlobantTraining.Controllers
{
    public class TypeProductsController : Controller
    {
        private readonly ITypeProductBusiness _typeProductBusiness;

        public TypeProductsController(ITypeProductBusiness typeProductBusiness)
        {
            _typeProductBusiness = typeProductBusiness;
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.Titulo = "Tipo Producto";
            return View(await _typeProductBusiness.GetTypeProducts());
        }

        public IActionResult Create()
        {
            ViewBag.Titulo = "Crear Tipo Producto";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TypeProductDto typeProductDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.Titulo = "Crear Tipo Producto";
                    _typeProductBusiness.Create(typeProductDto);
                    var save = await _typeProductBusiness.SaveChanges();
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
            return View(typeProductDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                try
                {
                    var typeProduct = await _typeProductBusiness.GetTypeProductId(id.Value);
                    if (typeProduct != null)
                    {
                        ViewBag.Titulo = "Editar Tipo Producto";
                        return View(typeProduct);
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
        public async Task<IActionResult> Edit(int id, TypeProductDto typeProductDto)
        {
            if (id != typeProductDto.TypeProductId)
            {
                try
                {
                    _typeProductBusiness.Edit(typeProductDto);
                    var edit = await _typeProductBusiness.SaveChanges();
                    if (edit) 
                    {
                        return RedirectToAction();
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
                    _typeProductBusiness.Edit(typeProductDto);
                    var edit = await _typeProductBusiness.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_typeProductBusiness.TypeProductExists(typeProductDto.TypeProductId))
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
            return View(typeProductDto);
        }

        
    }
}
