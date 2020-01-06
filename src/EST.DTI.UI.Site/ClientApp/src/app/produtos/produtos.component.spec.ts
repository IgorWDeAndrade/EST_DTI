/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ProdutosComponent } from './produtos.component';

let component: ProdutosComponent;
let fixture: ComponentFixture<ProdutosComponent>;

describe('produtos component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ProdutosComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ProdutosComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});