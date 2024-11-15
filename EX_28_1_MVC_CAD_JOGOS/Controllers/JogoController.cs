using EX_28_1_MVC_CAD_JOGOS.DAO;
using EX_28_1_MVC_CAD_JOGOS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace EX_28_1_MVC_CAD_JOGOS.Controllers
{
    public class JogoController : PadraoController<JogoViewModel>
    {
        public JogoController()
        {
            dao = new JogoDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(JogoViewModel model, string Operacao)
        {
            base.ValidaDados(model, Operacao);
            if (string.IsNullOrEmpty(model.Descricao))
                ModelState.AddModelError("Descricao", "Valor obrigatório, digite uma descrição!");
            if (model.Valor < 0)
                ModelState.AddModelError("Valor", "Valor inválido, o valor não pode ser menor que 0!");
            if (model.DataAquisicao > DateTime.Now || model.DataAquisicao < new DateTime(1900, 1, 1))
                ModelState.AddModelError("DataAquisicao", "Data inválida! Digite uma entre 01/01/1900 e hoje!");
            if (model.CategoriaID <= 0)
                ModelState.AddModelError("CategoriaId", "CategoriaID inválida, o número tem que ser maior que 0!");
        }

        private void PreparaComboCategorias()
        {
            CategoriaDAO dao = new CategoriaDAO();
            var lista = dao.Lista();

            List<SelectListItem> listaRetorno = new List<SelectListItem>();
            foreach (var categoria in lista)
            {
                listaRetorno.Add(new SelectListItem(categoria.Descricao, categoria.Id.ToString()));
            }

            ViewBag.Categorias = listaRetorno;
        }

        protected override void PreencheDadosParaView(string Operacao, JogoViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            model.DataAquisicao = DateTime.Now;
            PreparaComboCategorias();
        }
    }
}
