// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/TRA/menu/TRA_11',
			name: 'menu-TRA_11',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_11/QMenuTra11.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '11',
				baseArea: 'AGENT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
	]
}
