import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-rank',
  templateUrl: './rank.component.html',
  styleUrls: ['./rank.component.scss']
})
export class RankComponent implements OnInit {

  songs= new Array(10);

  constructor() { }

  ngOnInit() {
  }

}
