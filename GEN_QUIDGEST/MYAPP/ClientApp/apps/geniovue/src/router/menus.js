// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/TRA/menu/TRA_321',
			name: 'menu-TRA_321',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_321/QMenuTra321.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '321',
				baseArea: 'CITY',
				hasInitialPHE: false,
				humanKeyFields: [],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/TRA/menu/TRA_411',
			name: 'menu-TRA_411',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_411/QMenuTra411.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '411',
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
			path: '/:culture/:system/TRA/menu/TRA_41',
			name: 'menu-TRA_41',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_41/QMenuTra41.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '41',
				baseArea: 'BROKER',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
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
				baseArea: 'PHOTO_ALBUM',
				hasInitialPHE: false,
				humanKeyFields: [],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/TRA/menu/TRA_311',
			name: 'menu-TRA_311',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_311/QMenuTra311.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '311',
				baseArea: 'COUNTRY',
				hasInitialPHE: false,
				humanKeyFields: [],
				isPopup: false
			}
		},
	]
}
