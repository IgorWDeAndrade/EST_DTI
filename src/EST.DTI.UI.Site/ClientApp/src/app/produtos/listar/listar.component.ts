import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../../../services/produto.service';
import { ProdutoDataService } from '../../../services/produto-data.service';
import { Observable } from 'rxjs';
import { Produto } from '../../../ViewModel/produto';

@Component({
  selector: 'app-listar',
  templateUrl: './listar.component.html',
  styleUrls: ['./listar.component.css']
})
/** listar component*/
export class ListarComponent implements OnInit {

  produtos: Observable<any>;

  constructor(private _produtoService: ProdutoService, private _produtoDataService: ProdutoDataService) {

  }

  ngOnInit(): void {
    this.produtos = this._produtoService.obterTodos();
  }

  deletar(produto: Produto) {
    this._produtoService.deletar(produto.id);
  }

  editar(produto: Produto, chave: number) {
    this._produtoDataService.obterProduto(produto, chave);
  }
}
