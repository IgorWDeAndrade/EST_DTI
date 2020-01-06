import { Injectable } from '@angular/core';
import { Produto } from '../ViewModel/produto';
import { environment } from '../environments/environment.prod';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {
  constructor(private _http: HttpClient) {
  }

  adicionar(produto: Produto) {
    const headers = new HttpHeaders().set("content-type", "application/json");
    var body = {
      id: produto.id,
      ativo: produto.ativo,
      dataCadastro: produto.dataCadastro,
      quantidade: produto.quantidade,
      valorUnidade: produto.valorUnidade,
      descricao: produto.descricao
    }
    return this._http.post<Observable<Produto>>(environment.api + 'Produtos/' + 'Criar/', body, { headers }).subscribe();
  }

  atualizar(produto: Produto) {
    const headers = new HttpHeaders().set("content-type", "application/json");
    const params = new HttpParams().set("id", produto.id.toString());
    var body = {
      id : produto.id,
      ativo: produto.ativo,
      dataCadastro: produto.dataCadastro,
      quantidade: produto.quantidade,
      valorUnidade: produto.valorUnidade,
      descricao: produto.descricao
    }
    return this._http.put<Observable<Produto>>(environment.api + 'Produtos/' + 'Atualizar/' + produto.id, body, {
      headers,
      params
    }).subscribe();
  }

  deletar(id: number) {
    this._http.delete<void>(environment.api + 'Produtos/' + 'ExcluirPorId/' + id).subscribe();
  }

  obterTodos() {
    console.log(environment.api);
    return this._http.get<Observable<any>>(environment.api + 'Produtos/' + 'ObterTodos');
  }
}
