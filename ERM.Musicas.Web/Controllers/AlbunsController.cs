﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERM.Musicas.AcessoDados.Entity.Context;
using ERM.Musicas.Dominio;
using AutoMapper;
using ERM.Musicas.Web.ViewModels.Album;
using ERM.Repositorio.Comum;
using ERM.Musicas.Repositorio.Entity;
using ERM.Musicas.Web.Filtros;

namespace ERM.Musicas.Web.Controllers
{
    [Authorize]
    public class AlbunsController : Controller
    {
        private IRepositorioGenerioco < Album, int> repositorioAlbuns = new AlbunsRepositorio ( new MusicasDbContext() );

        
        // GET: Albuns
        [LogActionFilter]
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Album>, List<AlbumShowViewModel> >( repositorioAlbuns.Selecionar() ));
        }

        public ActionResult FiltrarByNome(string pesquisa)
        {
            List<Album> albuns = repositorioAlbuns.Selecionar().Where(a => a.Nome.Contains(pesquisa)).ToList();
            List<AlbumShowViewModel> viewModels = Mapper.Map<List<Album>,List<AlbumShowViewModel> > (albuns);
            return Json(viewModels,JsonRequestBehavior.AllowGet);
        }

        // GET: Albuns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = repositorioAlbuns.SelecionarPorId(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Album,AlbumShowViewModel>(album));
        }

        // GET: Albuns/Create
        [Authorize(Roles ="ADMINISTRADOR")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albuns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMINISTRADOR")]
        public ActionResult Create([Bind(Include = "Id,Nome,Ano,Observacoes,Email")] AlbumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Album album = Mapper.Map<AlbumViewModel, Album>(viewModel);
                repositorioAlbuns.Inserir(album);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Albuns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = repositorioAlbuns.SelecionarPorId(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View( Mapper.Map<Album,AlbumViewModel>(album) );
        }

        // POST: Albuns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Ano,Observacoes,Email")] AlbumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Album album = Mapper.Map<AlbumViewModel, Album>(viewModel);
                repositorioAlbuns.Alterar(album);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Albuns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = repositorioAlbuns.SelecionarPorId(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Album,AlbumShowViewModel>(album));
        }

        // POST: Albuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositorioAlbuns.ExcluirById(id);
            return RedirectToAction("Index");
        }
    }
}
