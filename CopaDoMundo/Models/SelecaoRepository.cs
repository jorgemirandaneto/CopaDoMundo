using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaDoMundo.Models
{
    public class SelecaoRepository : IDisposable
    {
        private bool disposed = false;
        public K19Context context;

        public SelecaoRepository(K19Context context)
        {
            this.context = context;
        }

        public void Adiciona(Selecao selecao)
        {
            context.Selecoes.Add(selecao);
        }

        public List<Selecao> Selecoes
        {
            get
            {
                return context.Selecoes.ToList();
            }
        }

        public void Salvar()
        {
            context.SaveChanges();
        }

        public Selecao Busca(int id)
        {
            return context.Selecoes.Find(id);
        }

        public void Remove(int id)
        {
            Selecao selecao = Busca(id);
            context.Selecoes.Remove(selecao);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
