import {Injectable, Inject} from '@angular/core';
import {TRANSLATIONS} from './translation';

@Injectable()
export class TranslateService{

    private _currentLang: string;

    public getCurrentLang(): string {
        return this._currentLang;
    }

    constructor(@Inject(TRANSLATIONS) private _translations: any){

    }

    public use (lang: string) {
        this._currentLang = lang;
    }

    private translate(key: string): string {
        let translation = key;
        if(this._translations[this.getCurrentLang()][key])
        {
            return this._translations[this.getCurrentLang()][key];
        }
        return translation;
    }

    public instant(key:string){
        return this.translate(key);
    }
}
