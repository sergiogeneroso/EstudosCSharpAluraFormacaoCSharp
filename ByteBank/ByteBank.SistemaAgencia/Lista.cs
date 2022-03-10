using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class Lista<T>
    {
        private T[] _itens;
        private int _proximaPosicao;

        public int Tamanho
        {
            get { return _proximaPosicao;}
        }

        public Lista(int capacidadeInicial = 5)
        {
            _itens = new T[capacidadeInicial];
            _proximaPosicao = 0;
        }
        public void Remover(T item)
        {
            int indiceItem = -1;

            for(int i = 0; i < _proximaPosicao; i++)
            {
                if (_itens[i].Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            for(int i = indiceItem; i <_proximaPosicao - 1; i++)
            {
               _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
        }

        public T GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
            }

        public void Adicionar(T item)
        {
            VerificarCapacidade(_proximaPosicao + 1);

            _itens[_proximaPosicao] = item;

            _proximaPosicao++;

        }

        public void AdicionarVarios(params T[] itens)
        {
            foreach(T item in itens)
            {
                Adicionar(item);
            }
        }

        

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = _itens.Length * 2;

            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            AtualizarArrayDeItens(tamanhoNecessario);
        }

        private void AtualizarArrayDeItens(int tamanhoNecessario)
        {
            T[] novoArray = new T[tamanhoNecessario];

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];
            }

            _itens = novoArray;
        }

        public T this[int indice]
        {
            get
            {
                return this.GetItemNoIndice(indice);
            }
        }
    }
}
