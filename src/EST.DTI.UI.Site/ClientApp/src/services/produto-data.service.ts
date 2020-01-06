import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Produto } from '../ViewModel/produto';

@Injectable({
  providedIn: 'root'
})
export class ProdutoDataService {
    constructor() {

  }

  private produtoSource = new BehaviorSubject({ produto: null, chave: 0 });
  produtoAtual = this.produtoSource.asObservable();

  obterProduto(produto: Produto, chave: number) {
    this.produtoSource.next({ produto: produto, chave: chave });
  }
}
