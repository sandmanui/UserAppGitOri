import { PipeTransform, Pipe} from '@angular/core';
import {TranslateService} from './translate.service';

@Pipe({
    name: 'translatetp'
})

export class TranslatePipe implements PipeTransform {
    constructor(private _translate: TranslateService){}
    transform(value: string, ...args: any[]) {
        return this._translate.instant(value);
    }

}