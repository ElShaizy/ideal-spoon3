import { propsConverter } from './routeUtils.js'

export default function getFormsRoutes()
{
	return [
		{
			path: '/:culture/:system/:module/form/F_AGENT/:mode/:id?',
			name: 'form-F_AGENT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFAgent/QFormFAgent.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'AGENT',
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
	]
}
