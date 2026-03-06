/* eslint-disable @typescript-eslint/no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import FormViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
import modelFieldType from '@quidgest/clientapp/models/fields'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@quidgest/clientapp/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable @typescript-eslint/no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends FormViewModelBase
 */
export default class ViewModel extends FormViewModelBase
{
	/**
	 * Creates a new instance of the ViewModel.
	 * @param {object} vueContext - The Vue context
	 * @param {object} options - The options for the ViewModel
	 * @param {object} values - A ViewModel instance to copy values from
	 */
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line @typescript-eslint/no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'F_AGENT',
			area: 'AGENT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_agent',
				updateFilesTickets: 'UpdateFilesTicketsF_agent',
				setFile: 'SetFileF_agent'
			}
		})

		/** The primary key. */
		this.ValCodagent = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodagent',
			originId: 'ValCodagent',
			area: 'AGENT',
			field: 'CODAGENT',
			description: '',
		}).cloneFrom(values?.ValCodagent))
		this.stopWatchers.push(watch(() => this.ValCodagent.value, (newValue, oldValue) => this.onUpdate('agent.codagent', this.ValCodagent, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValPhoto = reactive(new modelFieldType.Image({
			id: 'ValPhoto',
			originId: 'ValPhoto',
			area: 'AGENT',
			field: 'PHOTO',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhoto))
		this.stopWatchers.push(watch(() => this.ValPhoto.value, (newValue, oldValue) => this.onUpdate('agent.photo', this.ValPhoto, newValue, oldValue)))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'AGENT',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('agent.name', this.ValName, newValue, oldValue)))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'AGENT',
			field: 'EMAIL',
			maxLength: 256,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail))
		this.stopWatchers.push(watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('agent.email', this.ValEmail, newValue, oldValue)))

		this.ValBirthdate = reactive(new modelFieldType.Date({
			id: 'ValBirthdate',
			originId: 'ValBirthdate',
			area: 'AGENT',
			field: 'BIRTHDATE',
			description: computed(() => this.Resources.BIRTHDATE22743),
		}).cloneFrom(values?.ValBirthdate))
		this.stopWatchers.push(watch(() => this.ValBirthdate.value, (newValue, oldValue) => this.onUpdate('agent.birthdate', this.ValBirthdate, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFAgentViewModel instance.
	 * @returns {QFormFAgentViewModel} A new instance of QFormFAgentViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodagent'

	get QPrimaryKey() { return this.ValCodagent.value }
	set QPrimaryKey(value) { this.ValCodagent.updateValue(value) }
}
