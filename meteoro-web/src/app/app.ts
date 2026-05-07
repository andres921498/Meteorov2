import { Component, OnInit, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  // 2. Agrégalo aquí en el array de imports
  imports: [CommonModule, /* ... otros como RouterOutlet, etc. */], 
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App implements OnInit {
  private http = inject(HttpClient);
  private api = 'http://localhost:5084/api';

  public estaciones = signal<any[]>([]);
  public sensores = signal<any[]>([]);
  public lecturas = signal<any[]>([]);
  public alertas = signal<any[]>([]);
  protected title = signal('Sistema Meteoro v2');

  ngOnInit() { this.cargarTodo(); }

  cargarTodo() {
    this.http.get<any[]>(`${this.api}/Stations`).subscribe(d => this.estaciones.set(d));
    this.http.get<any[]>(`${this.api}/Sensors`).subscribe(d => this.sensores.set(d));
    this.http.get<any[]>(`${this.api}/Readings`).subscribe(d => this.lecturas.set(d));
    this.http.get<any[]>(`${this.api}/Alerts`).subscribe(d => this.alertas.set(d));
  }

  // --- MÉTODOS DE GUARDADO ---
  guardarEstacion(nombre: string, barrio: string, lat: number, lon: number, estado: string) {
    const data = { nombre, barrio, latitud: lat, longitud: lon, estado };
    this.http.post(`${this.api}/Stations`, data).subscribe(() => this.cargarTodo());
  }

  guardarSensor(estacionId: number, tipoSensor: string, unidadMedida: string) {
    const data = { estacionId, tipoSensor, unidadMedida };
    this.http.post(`${this.api}/Sensors`, data).subscribe(() => this.cargarTodo());
  }

  guardarLectura(sensorId: number, valor: number) {
    const data = { sensorId, valor, fechaHora: new Date().toISOString() };
    this.http.post(`${this.api}/Readings`, data).subscribe(() => this.cargarTodo());
  }

  guardarAlerta(estacionId: number, mensaje: string, nivelRiesgo: string) {
    const data = { estacionId, mensaje, nivelRiesgo, fechaEmision: new Date().toISOString() };
    this.http.post(`${this.api}/Alerts`, data).subscribe(() => this.cargarTodo());
  }

  // --- MÉTODOS DE ELIMINACIÓN (NUEVOS) ---
  eliminarEstacion(id: number) {
    if (confirm('¿Eliminar esta estación? Se borrarán sus datos asociados.')) {
      this.http.delete(`${this.api}/Stations/${id}`).subscribe(() => this.cargarTodo());
    }
  }

  eliminarSensor(id: number) {
    if (confirm('¿Seguro que quieres borrar este sensor?')) {
      this.http.delete(`${this.api}/Sensors/${id}`).subscribe(() => this.cargarTodo());
    }
  }

  eliminarLectura(id: number) {
    // Borrado directo para lecturas (suelen ser muchas)
    this.http.delete(`${this.api}/Readings/${id}`).subscribe(() => this.cargarTodo());
  }

  eliminarAlerta(id: number) {
    if (confirm('¿Deseas quitar esta alerta del sistema?')) {
      this.http.delete(`${this.api}/Alerts/${id}`).subscribe(() => this.cargarTodo());
    }
  }
}