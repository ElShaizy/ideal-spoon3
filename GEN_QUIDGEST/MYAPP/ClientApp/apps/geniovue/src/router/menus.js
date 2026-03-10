// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/TRA/menu/TRA_421',
			name: 'menu-TRA_421',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_421/QMenuTra421.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '421',
				baseArea: 'CITY',
				hasInitialPHE: false,
				humanKeyFields: [],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/TRA/menu/TRA_21',
			name: 'menu-TRA_21',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_21/QMenuTra21.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '21',
				baseArea: 'PROPERTIES',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle', 'ValPrice'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/TRA/menu/TRA_511',
			name: 'menu-TRA_511',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_511/QMenuTra511.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '511',
				baseArea: 'PROPERTIES',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle', 'ValPrice'],
				limitations: ['broker' /* DB */],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/TRA/menu/TRA_11',
			name: 'menu-TRA_11',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_11/QMenuTra11.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '11',
				baseArea: 'BROKER',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/TRA/menu/TRA_51',
			name: 'menu-TRA_51',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_51/QMenuTra51.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '51',
				baseArea: 'BROKER',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/TRA/menu/TRA_31',
			name: 'menu-TRA_31',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_31/QMenuTra31.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '31',
				baseArea: 'PHOTO_ALBUM',
				hasInitialPHE: false,
				humanKeyFields: [],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/TRA/menu/TRA_411',
			name: 'menu-TRA_411',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_411/QMenuTra411.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '411',
				baseArea: 'COUNTRY',
				hasInitialPHE: false,
				humanKeyFields: [],
				isPopup: false
			}
		},
	]
}
