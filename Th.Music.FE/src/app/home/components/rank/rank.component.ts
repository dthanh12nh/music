import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-rank',
  templateUrl: './rank.component.html',
  styleUrls: ['./rank.component.scss']
})
export class RankComponent implements OnInit {

  songs: number[] = new Array(10);

  constructor() { 
    for (let i = 0; i < 10; i++) {
      this.songs[i] = i + 1;
    }
  }

  ngOnInit() {
  }

}
