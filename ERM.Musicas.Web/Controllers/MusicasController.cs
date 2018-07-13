using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERM.Musicas.AcessoDados.Entity.Context;
using ERM.Musicas.Dominio;
using ERM.Musicas.Repositorio.Entity;
using ERM.Repositorio.Comum;
using AutoMapper;
using ERM.Musicas.Web.ViewModels.Musica;
using ERM.Musicas.Web.ViewModels.Album;

namespace ERM.Musicas.Web.Controllers
{
    [Authorize]
    public class MusicasController : Controller
    {
        private IRepositorioGenerioco<Musica, long> repositorioMusicas = new MusicasRepositorio(new MusicasDbContext());
        private IRepositorioGenerioco<Album, int> repositorioAlbuns = new AlbunsRepositorio(new MusicasDbContext());

        // GET: Musicas
        public ActionResult Index()
        {
            
            return View(Mapper.Map< List<Musica>, List<MusicaShowViewModel> >(repositorioMusicas.Selecionar()));
        }

        // GET: Musicas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica,MusicaShowViewModel>(musica));
        }

        // GET: Musicas/Create
        public ActionResult Create()
        {
            List<AlbumShowViewModel> albuns = Mapper.Map<List<Album>, List<AlbumShowViewModel>>(repositorioAlbuns.Selecionar());
            SelectList DropDownAlbuns = new SelectList(albuns, "Id", "Nome");
            ViewBag.DropDownAlbuns = DropDownAlbuns;
            return View();
        }

        // POST: Musicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,IdAlbum")] MusicaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(viewModel);
                repositorioMusicas.Inserir(musica);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Musicas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            List<AlbumShowViewModel> albuns = Mapper.Map<List<Album>, List<AlbumShowViewModel>>(repositorioAlbuns.Selecionar());
            SelectList DropDownAlbuns = new SelectList(albuns, "Id", "Nome");
            ViewBag.DropDownAlbuns = DropDownAlbuns;
            return View(Mapper.Map<Musica,MusicaViewModel>(musica));
        }

        // POST: Musicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,IdAlbum")] MusicaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(viewModel);
                repositorioMusicas.Alterar(musica);
                return RedirectToAction("Index");
            }
            
            return View(viewModel);
        }

        // GET: Musicas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View( Mapper.Map<Musica,MusicaShowViewModel>(musica) );
        }

        // POST: Musicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repositorioMusicas.ExcluirById(id);
            return RedirectToAction("Index");
        }

    }
}
