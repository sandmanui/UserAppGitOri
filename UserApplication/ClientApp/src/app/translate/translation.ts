import { InjectionToken } from '@angular/core';

import {LANG_EN_NAME,LANG_EN_TRANS} from './lang-en';

export const TRANSLATIONS = new InjectionToken<string>('translations');

export const dictionary = {
    [LANG_EN_NAME]: LANG_EN_TRANS
}

export const TRANSLATION_PROVIDERS = [
    {provide: TRANSLATIONS,useValue: dictionary }
];