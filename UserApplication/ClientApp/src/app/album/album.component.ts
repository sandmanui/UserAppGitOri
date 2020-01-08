import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators, FormArray, FormControl} from '@angular/forms';

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.css']
})
export class AlbumComponent implements OnInit {
  albumform: FormGroup;
  tp: FormArray;
  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.albumform = this.formBuilder.group({
      name: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required]],
      address: this.formBuilder.group({
        street: [null, Validators.required],
        street2: [null],
        zipCode: [null, Validators.required],
        city: [null, Validators.required],
        state: [null, Validators.required],
        country: [null, Validators.required]}),
      aliases: this.formBuilder.array([
        this.formBuilder.control('')
      ]) 
    });

    this.tp = this.albumform.get('aliases') as FormArray;

  }

  

  get aliases(){
    return this.albumform.get('aliases') as FormArray;
  }

  addAlias(){
    this.aliases.push(this.formBuilder.control(''));
  }

  displayFieldCss(field: string) {
    return {
      'has-error': this.isFieldValid(field),
      'has-feedback': this.isFieldValid(field)
    };
  }

  isFieldValid(field: string) {
    return !this.albumform.get(field).valid && this.albumform.get(field).touched;
  }
onSubmit() {
  if (this.albumform.valid) {
    console.log('form submitted');
  } else {
    this.validateAllFormFields(this.albumform); //{7}
  }
}

validateAllFormFields(formGroup: FormGroup) {         //{1}
  Object.keys(formGroup.controls).forEach(field => {  //{2}
    const control = formGroup.get(field);             //{3}
    if (control instanceof FormControl) {             //{4}
      control.markAsTouched({ onlySelf: true });
    } else if (control instanceof FormGroup) {        //{5}
      this.validateAllFormFields(control);            //{6}
    }
  });
}

reset(){
  this.albumform.reset();
}

}
