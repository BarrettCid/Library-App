import { Injectable } from '@angular/core';
import { BaseService } from '../base.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackBarService {

  constructor(private snackBar: MatSnackBar) { }

  openSnackBar(message: string, action: string){
    this.snackBar.open(message, action);
  }

}