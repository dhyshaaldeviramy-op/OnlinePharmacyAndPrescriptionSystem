import { Routes } from '@angular/router';
import { MedicineCatalog } from './features/admin/medicine-catalog/medicine-catalog/medicine-catalog';
import { MedicineSearch } from './features/customer/medicine-search/medicine-search';
import { PrescriptionUpload } from './features/customer/prescription-upload/prescription-upload';
import { PrescriptionApproval } from './features/admin/prescription-approval/prescription-approval';
import { Cart } from './features/customer/cart/cart';
import { Checkout } from './features/customer/checkout/checkout';
import { OrderManagement } from './features/admin/order-management/order-management';
import { OrderHistory } from './features/customer/order-history/order-history';
import { Dashboard } from './features/admin/dashboard/dashboard';
import { Feedback } from './features/customer/feedback/feedback';
import { Alert } from './features/admin/alert/alert';

export const routes: Routes = [
  { path: '', redirectTo: 'customer/search', pathMatch: 'full' },

  // CUSTOMER
  { path: 'customer/search', component: MedicineSearch },
  { path: 'customer/upload-prescription', component: PrescriptionUpload },
  { path: 'customer/cart', component: Cart },
  { path: 'customer/checkout', component: Checkout },
  { path: 'customer/history', component: OrderHistory },
  { path: 'customer/feedback', component: Feedback },

  // ADMIN
  { path: 'admin/medicines', component: MedicineCatalog },
  { path: 'admin/prescriptions', component: PrescriptionApproval },
  { path: 'admin/orders', component: OrderManagement },
  { path: 'admin/dashboard', component: Dashboard },
  { path: 'admin/alerts', component: Alert },

  // FALLBACK
  { path: '**', redirectTo: 'customer/search' }
];
