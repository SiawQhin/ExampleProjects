import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, map , tap} from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OpenaiService
 {

  constructor(private http: HttpClient) { }

  //Change api url to your local ip address
  private apiUrl="http://10.211.55.3:5175/api/LeetCode";
  
  postData(data: any) : Observable<any>{
    console.log('making postData to openai');
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')

      return this.http.post(this.apiUrl, data, { headers });
  }
}

