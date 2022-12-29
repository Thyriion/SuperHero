import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { SuperHero } from '../models/super-hero';

@Injectable({
  providedIn: 'root',
})
export class SuperHeroService {
  private url = 'SuperHero';
  constructor(private http: HttpClient) {}

  public getSuperHeroes(): Observable<SuperHero[]> {
    return this.http.get<SuperHero[]>('https://localhost:7092/api/SuperHero');
  }

  public updateSuperHero(hero: SuperHero): Observable<SuperHero[]> {
    return this.http.put<SuperHero[]>(
      'https://localhost:7092/api/SuperHero',
      hero
    );
  }

  public createSuperHero(hero: SuperHero): Observable<SuperHero[]> {
    return this.http.post<SuperHero[]>(
      'https://localhost:7092/api/SuperHero',
      hero
    );
  }

  public deleteSuperHero(hero: SuperHero): Observable<SuperHero[]> {
    return this.http.delete<SuperHero[]>(
      `https://localhost:7092/api/SuperHero/${hero.id}`
    );
  }
}
