import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public filteredEvents: any = [];
  widthImg: number = 150;
  marginImg: number = 2;
  showImage: boolean = true;
  private _filterList: string = "";

  public get filterList(): string{
    return this._filterList;
  }

  public set filterList(value: string){
    this._filterList = value;
    this.filteredEvents = this.filterList ? this.filterEvents(this.filterList) : this.eventos
  }

  filterEvents(filterBy: string) : any{
    filterBy = filterBy.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filterBy) !== -1
      ||
      evento.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    )
  }

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEventos();
  }

  changeImage() {
    this.showImage = !this.showImage
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response;
        this.filteredEvents = this.eventos;
      },
      error => console.log(error)
    );
  }
}
