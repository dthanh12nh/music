import { Injectable } from '@angular/core';
import { ComponentPortal } from '@angular/cdk/portal';
import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { LoaderComponent } from '../components/loader/loader.component';

@Injectable({
  providedIn: 'root'
})
export class LoaderService {

  private overlayRef: OverlayRef = null;

  constructor(
    private overlay: Overlay
  ) { }

  show() {
    if (!this.overlayRef) {
      this.overlayRef = this.overlay.create();
    }

    const loaderPortal = new ComponentPortal(LoaderComponent);
    this.overlayRef.attach(loaderPortal);
  }

  hide() {
    if (this.overlayRef) {
      this.overlayRef.detach();
    }
  }
}
