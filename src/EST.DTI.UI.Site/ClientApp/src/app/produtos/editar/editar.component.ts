import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../../../services/produto.service';
import { ProdutoDataService } from '../../../services/produto-data.service';
import { Produto } from '../../../ViewModel/produto';

@Component({
    selector: 'app-editar',
    templateUrl: './editar.component.html',
    styleUrls: ['./editar.component.css']
})
/** editar component*/
export class EditarComponent implements OnInit {
  produto: Produto;
  chave: number = 0;

  constructor(private _produtoService: ProdutoService, private _produtoDataService: ProdutoDataService) {

  }

  ngOnInit(): void {
    this.produto = new Produto();
    this._produtoDataService.produtoAtual.subscribe(data => {
      if (data.produto && data.chave) {
        this.produto = new Produto();
        this.produto.id = data.produto.id;
        this.produto.descricao = data.produto.descricao;
        this.produto.quantidade = data.produto.quantidade;
        this.produto.valorUnidade = data.produto.valorUnidade;
        this.chave = data.chave;
      }
    });
  }

  salvar() {
    if (this.chave) {
      this._produtoService.atualizar(this.produto);
    } else {
      this._produtoService.adicionar(this.produto);
    }

    this.produto = new Produto();
    this.chave = null;
  }
}
