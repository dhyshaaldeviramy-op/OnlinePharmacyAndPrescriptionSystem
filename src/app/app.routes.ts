import { Routes } from '@angular/router';
import { MedicineCatalog } from './features/admin/medicine-catalog/medicine-catalog/medicine-catalog';
import { MedicineSearch } from './features/customer/medicine-search/medicine-search';
import { PrescriptionUpload } from './features/customer/prescription-upload/prescription-upload';
import { PrescriptionApproval } from './features/admin/prescription-approval/prescription-approval';
import { Cart } from './features/customer/cart/cart';

export const routes: Routes = [
   { path: '', redirectTo: 'admin/medicines', pathMatch: 'full' },

  { path: 'admin/medicines', component: MedicineCatalog },

  { path: 'search', component: MedicineSearch },

  { path: 'upload-prescription', component: PrescriptionUpload },

  { path: 'approve-prescription', component: PrescriptionApproval },

{
  path: 'cart',
  component: Cart
}
];
